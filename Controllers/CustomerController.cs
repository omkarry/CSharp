using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD_operations.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> _customers = new();
        private static int _nextId = 0;
        private static List<Location> _locations = new();
        private static int _nextLocationId = 0;

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns>List of cutomers</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Customers
        ///     
        /// </remarks>
        /// <response code="200">Returns List of customers</response>
        /// <response code="400">Customers not available</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet("Customers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                if (_customers == null)
                    return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "No customers available"});
                else
                {
                    List<Customer> customers = _customers;
                    return Ok(new ApiResponse<List<Customer>> { StatusCode = 200, Message = "List of customers", Value = customers });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns specific customer
        /// </summary>
        /// <returns>A requested customer</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Customer/{id}
        ///
        /// </remarks>
        /// <response code="200">Returns the requested customer</response>
        /// <response code="400">Customer not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet("Customer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int id)
        {
            try
            {
                foreach (Customer customer in _customers.ToList())
                {
                    if (customer.Id == id)
                        return Ok(new ApiResponse<Customer> { StatusCode = 200, Message = "Customer details", Value = customer});
                }
                return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "Customer not found"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates a Customer.
        /// </summary>
        /// <returns>A newly created Customer</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Customer
        ///     {
        ///        "id": 0,
        ///        "firstName": string,
        ///        "lastName": string,
        ///        "locations": [
        ///             {
        ///                 "id": 0,
        ///                 "addreess": string
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created customer</response>
        /// <response code="500">Internal server Error</response>
        [HttpPost("Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Customer> Post(Customer customer)
        {
            try
            {
                customer.Id = ++_nextId;
                if (customer.Locations.Count == 0)
                    _customers.Add(customer);
                else
                {
                    foreach (Location customerLocation in customer.Locations.ToList())
                    {
                        bool isLocationPresent = false;
                        int locationId = 0;
                        if (_locations.Count == 0)
                        {
                            customerLocation.Id = ++_nextLocationId;
                            _locations.Add(customerLocation);
                        }
                        else
                        {
                            //foreach (Location location in _locations.ToList())
                            //{
                            //    if (location.Address.ToLower() == customerLocation.Address.ToLower())
                            //    {
                            //        isLocationPresent = true;
                            //        locationId = location.Id;
                            //        break;
                            //    }
                            //}

                            int index = _locations.ToList().FindIndex(c =>  c.Address == customerLocation.Address);
                            if (index != -1)
                            {
                                customerLocation.Id = _locations[index].Id;
                            }
                            else
                            {
                                customerLocation.Id = ++_nextLocationId;
                                _locations.Add(customerLocation);
                            }
                        }
                    }
                    _customers.Add(customer);
                }
                return Ok(new ApiResponse<Customer> { StatusCode = 200, Message = "Customer added successfully", Value = customer });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <returns>Updated customer</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Customer
        ///     {
        ///        "id": 0,
        ///        "firstName": string,
        ///        "lastName": string,
        ///        "locations": [
        ///             {
        ///                 "id": 0,
        ///                 "addreess": string
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated customer</response>
        /// <response code="400">Customer not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPut("Customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Customer> Put(Customer customer)
        {
            try
            {
                int index = _customers.FindIndex(c => c.Id == customer.Id);
                if (index != -1)
                {
                    foreach (Location customerLocation in customer.Locations.ToList())
                    {
                        bool isLocationPresent = false;
                        int locationId = 0;
                        if (_locations.Count == 0)
                        {
                            customerLocation.Id = ++_nextLocationId;
                            _locations.Add(customerLocation);
                        }
                        else
                        {
                            //foreach (Location location in _locations.ToList())
                            //{
                            //    if (location.Address.ToLower() == customerLocation.Address.ToLower())
                            //    {
                            //        isLocationPresent = true;
                            //        locationId = location.Id;
                            //        break;
                            //    }
                            //}
                            //if (isLocationPresent)
                            //{
                            //    customerLocation.Id = locationId;
                            //}
                            int indexOfLocation = _locations.ToList().FindIndex(c => c.Address == customerLocation.Address);
                            if (indexOfLocation != -1)
                            {
                                customerLocation.Id = _locations[indexOfLocation].Id;
                            }
                            else
                            {
                                customerLocation.Id = ++_nextLocationId;
                                _locations.Add(customerLocation);
                            }
                        }
                    }
                    _customers[index] = customer;
                    return Ok(new ApiResponse<Customer> { StatusCode = 200, Message = "Customer updated successfully", Value = customer });
                }
                else
                    return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "Customer not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a Customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Customer/{id}
        ///
        /// </remarks>
        /// <response code="200">Customer deleted successfully</response>
        /// <response code="400">Customer not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpDelete("Customer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
                foreach (Customer customer in _customers.ToList())
                {
                    if (customer.Id == id)
                    {
                        Customer getCustomer = customer;
                        if (customer.Locations.Count == 0)
                        {
                            _customers.Remove(customer);
                            return Ok(new ApiResponse<object> { StatusCode = 200, Message = "Customer deleted successfully" });
                        }
                        else
                            return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "Customer not found" });
                    }
                }
                return BadRequest("Customer not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns all Locations
        /// </summary>
        /// <returns>List of locations</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Locations
        ///     
        /// </remarks>
        /// <response code="200">Returns List of locations</response>
        /// <response code="400">Customer not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet("Locations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Location>> GetLocation()
        {
            try
            {
                if (_locations == null)
                    return BadRequest(new ApiResponse<object> { StatusCode = 404, Message = "Locations not available" });
                else
                {
                    List<Location> locations = _locations;
                    return Ok(new ApiResponse<List<Location>> { StatusCode = 200, Message = "List of locations", Value = locations });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns specific location
        /// </summary>
        /// <returns>A requested location</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Location/{id}
        ///
        /// </remarks>
        /// <response code="200">Returns the requested location</response>
        /// <response code="400">Location not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet("Location/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetLocation(int id)
        {
            try
            {
                foreach (Location location in _locations.ToList())
                {
                    if (location.Id == id)
                        return Ok(new ApiResponse<Location> { StatusCode = 200, Message = "Location details", Value = location });
                }
                return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "Location not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Creates a Location.
        /// </summary>
        /// <returns>A newly created location</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Location
        ///     {
        ///         "id": 0,
        ///         "address": string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created location</response>
        /// <response code="500">Internal server Error</response>
        [HttpPost("Location")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Location> Post(Location location)
        {
            try
            {
                bool isLocationPresent = false;
                if (_locations.Count == 0)
                {
                    location.Id = ++_nextLocationId;
                    _locations.Add(location);
                }
                else
                {
                    foreach (Location loc in _locations)
                    {
                        if (loc.Address.ToLower() == location.Address.ToLower())
                            return BadRequest(new ApiResponse<object> { StatusCode = 400, Message = "Location already present" });
                    }
                    if (!isLocationPresent)
                    {
                        location.Id = ++_nextLocationId;
                        _locations.Add(location);
                    }
                }

                return Ok(new ApiResponse<Location> { StatusCode = 200, Message = "Location added successfully", Value = location });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <returns>Updated location</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Location
        ///     {
        ///         "id": 0,
        ///         "address": string
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated location</response>
        /// <response code="400">Location not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPut("Location")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Location> Put(Location location)
        {
            try
            {
                foreach (Customer customer in _customers.ToList())
                {
                    int index = customer.Locations.FindIndex(customerLocation => customerLocation.Id == location.Id);
                    if (!(index == -1))
                        customer.Locations[index] = location;
                }
                int indexOfLocation = _locations.FindIndex(c => c.Id == location.Id);
                if (indexOfLocation != -1)
                {
                    _locations[indexOfLocation] = location;
                    return Ok(new ApiResponse<Location> { StatusCode = 200, Message = "Location updated successfully", Value = location });
                }
                return BadRequest(new ApiResponse<object> { StatusCode = 404, Message = "Location not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Location/{id}
        ///
        /// </remarks>
        /// <response code="200">Location deleted successfully</response>
        /// <response code="500">Internal server Error</response>
        [HttpDelete("Location/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteLocation(int id)
        {
            try
            {
                foreach (Customer customer in _customers.ToList())
                {
                    //foreach (Location location in customer.Locations.ToList())
                    //{
                    //    if (location.Id == id)
                    //    {
                    //        customer.Locations.Remove(location);
                    //    }
                    //}
                    int index = customer.Locations.ToList().FindIndex(c => c.Id == id);
                    if (index != -1)
                    {
                        customer.Locations.RemoveAt(index);
                    }
                }
                foreach (Location location in _locations.ToList())
                {
                    if (location.Id == id)
                    {
                        _locations.Remove(location);
                        return Ok(new ApiResponse<Location> { StatusCode = 200, Message = "Location deleted successfully" });
                    }
                }
                return BadRequest(new ApiResponse<object> { StatusCode = 404, Message = "Location not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a location of particular customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Customer/{customerId}/Location/{locationId}
        ///
        /// </remarks>
        /// <response code="200">Customer's location deleted successfully</response>
        /// <response code="400">Customer with location not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpDelete("Customer/{customerId}/Location/{locationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCustomerLocation(int customerId, int locationId)
        {
            try
            {
                foreach (Customer customer in _customers.ToList())
                {
                    if (customerId == customer.Id)
                    {
                        //foreach (Location location in customer.Locations.ToList())
                        //{
                        //    if (location.Id == locationId)
                        //    {
                        //        customer.Locations.Remove(location);
                        //        return Ok("Customer location deleted successfully");
                        //    }
                        //}
                        int index = customer.Locations.ToList().FindIndex(c => c.Id == locationId);
                        if (index != -1)
                        {
                            customer.Locations.RemoveAt(index);
                            return Ok(new ApiResponse<Customer> { StatusCode = 200, Message = "Customer location deletedqQ1" });
                        }
                    }
                }
                return BadRequest(new ApiResponse<object> { StatusCode = 404, Message = "Location not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
