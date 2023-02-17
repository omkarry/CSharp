using System;
using System.Text.RegularExpressions;

namespace Models
{
    public class VehicleModel
    {
        public string ModelName{get; set;}
        public decimal ModelPrice{get; set;}
        public string ModelType{get; set;}

        public VehicleModel()
        {}

        public VehicleModel(string modelName, decimal modelPrice, string modelType)
        {
            ModelName = modelName;
            ModelPrice = modelPrice;
            ModelType = modelType;
        }
    }

    public class Bike : VehicleModel
    {
        public Bike()
        {}

        public Bike(string modelName, decimal modelPrice)
        {
            ModelName = modelName;
            ModelPrice = modelPrice;
            ModelType = "bike";
        }
    }


    public class Car : VehicleModel
    {
        public Car()
        {}

        public Car(string modelName, decimal modelPrice)
        {
            ModelName = modelName;
            ModelPrice = modelPrice;
            ModelType = "car";
        }
    }

    public class Distributor
    {
        public string DistributorName{get; set;}
        public VehicleModel[] VehicleModels;
        public double Commision{get; set;}
        
        public Distributor()
        {}

        public Distributor(string name, VehicleModel[] vehicleModels)
        {
            DistributorName = name;
            VehicleModels = vehicleModels;
        }
    }

    public class Company
    {
        public string CompanyName{get; set;}
        public Distributor[] Distributors;

        public Company()
        {}

        public Company(string name, Distributor[] distributors)
        {
            CompanyName = name;
            Distributors = distributors;
        }
    }

    public class Model
    {
        // public int  numOfBikeModels, numOfCarModels;
        public int numOfCompanies, numOfDistributors, numOfBikeModelsForDistributor, numOfCarModelsForDistributor, numOfVehicleModelsForDistributor;
        public string vehicleType, modelName, exit;
        public decimal basePrice = 0;

        public static void Main(string[] args)
        {
            //Take all the information from user
            Model model = new Model();

            do
            {
                // Enter the number of Companies
                Console.WriteLine("Enter the number of companies: ");
                model.numOfCompanies = int.Parse(Console.ReadLine());
                if(model.numOfCompanies < 0)
                    Console.WriteLine("Number of companies cannot be less than 0");
                else
                    break;
            }while(true);
            
            // Get company names
            Company[] companies = new Company[model.numOfCompanies];
            for(int i=0; i < model.numOfCompanies; i++)
            {
                Company company = new Company();

                Console.WriteLine($"Enter the name of the company {i+1}: ");
                company.CompanyName = Console.ReadLine();

                do
                {
                    // Get distributor information for company
                    Console.WriteLine($"Enter the number of ditributors for company {company.CompanyName}: ");
                    model.numOfDistributors = int.Parse(Console.ReadLine());
                    if (model.numOfDistributors < 0)
                        Console.WriteLine("Number of distributors cannot be less than 0");
                    else
                        break;
                }while(true);
                
                Distributor[] distributorsForCompany = new Distributor[model.numOfDistributors];
                for(int j=0; j < model.numOfDistributors; j++)
                {
                    Distributor distributor = new Distributor();

                    Console.WriteLine($"Enter the name of the distributor {j+1} for company {company.CompanyName}");
                    distributor.DistributorName = Console.ReadLine();
                    
                    do
                    {
                        Console.WriteLine("What type of vehicles distributor have? (bike/car/both)");
                        model.vehicleType = Console.ReadLine().ToLower();
                        if (!(model.vehicleType == "bike" || model.vehicleType == "car" || model.vehicleType == "both" ))
                            Console.WriteLine("Select type from the option (bike/car/both)");
                        else
                            break;
                    }while(true);
                                        
                    switch(model.vehicleType)
                    {
                        case "bike": // Get bike information for distributor
                            do
                            {
                                Console.WriteLine($"Enter the number of bike models for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                model.numOfBikeModelsForDistributor = int.Parse(Console.ReadLine());
                                if(model.numOfBikeModelsForDistributor < 0)
                                    Console.WriteLine("Number of bike models available cannot be less than 0");
                                else
                                    break;
                            }while(true);
                            
                            Bike[] bikeModelsForDistributor = new Bike[model.numOfBikeModelsForDistributor];
                            for(int k=0; k < model.numOfBikeModelsForDistributor; k++)
                            {
                                Bike bike = new Bike();
                                
                                Console.WriteLine($"Enter the name of bike model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                bike.ModelName = Console.ReadLine();
                                    
                                do
                                {
                                    Console.WriteLine($"Enter the base price of bike model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                    model.basePrice = decimal.Parse(Console.ReadLine());
                                    if(model.basePrice <= 0)
                                        Console.WriteLine("Bike base price cannot be less than 0 or 0");
                                    else
                                        break;
                                }while(true);

                                do 
                                {
                                    Console.WriteLine($"Enter the commision of distributor {distributor.DistributorName} on bike {bike.ModelName}: ");
                                    distributor.Commision = double.Parse(Console.ReadLine());
                                    if(distributor.Commision < 0 || distributor.Commision > 100)
                                        Console.WriteLine("Commision should be between 0 to 100");
                                    else
                                        bike.ModelPrice = (model.basePrice * (decimal)distributor.Commision / 100) + model.basePrice;
                                        break;
                                }while(true);

                                bikeModelsForDistributor[k] = new  Bike(bike.ModelName, bike.ModelPrice);
                            }
                            distributorsForCompany[j] = new Distributor(distributor.DistributorName, bikeModelsForDistributor);
                        break;

                        case "car": // Get car information for distributor
                            do 
                            {
                                Console.WriteLine($"Enter the number of car models for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                model.numOfCarModelsForDistributor = int.Parse(Console.ReadLine());
                                if(model.numOfCarModelsForDistributor <= 0)
                                    Console.WriteLine("Number of car models cannot be less than 0");
                                else
                                    break;
                            }while(true);
                            
                            Car[] carModelsForDistributor = new Car[model.numOfCarModelsForDistributor];
                            for(int k=0; k < model.numOfCarModelsForDistributor; k++)
                            {
                                Car car = new Car();

                                Console.WriteLine($"Enter the name of car model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                car.ModelName = Console.ReadLine();
                                                                    
                                do
                                {
                                    Console.WriteLine($"Enter the base price of car model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                    model.basePrice = decimal.Parse(Console.ReadLine());
                                    if(model.basePrice <= 0 ) 
                                        Console.WriteLine("Car model base price cannot be less than 0 or 0");
                                    else
                                        break;
                                }while(true);

                                do 
                                {
                                    Console.WriteLine($"Enter the commision of distributor {distributor.DistributorName} on car {car.ModelName}: ");
                                    distributor.Commision = Convert.ToDouble(Console.ReadLine());
                                    if(distributor.Commision < 0 || distributor.Commision > 100)
                                        Console.WriteLine("Commision should be between 0 to 100");
                                    else
                                        car.ModelPrice = (model.basePrice * (decimal)distributor.Commision / 100) + model.basePrice;
                                        break;
                                }while(true);
                                
                                carModelsForDistributor[k] = new  Car(car.ModelName, car.ModelPrice);
                            }
                            distributorsForCompany[j] = new Distributor(distributor.DistributorName, carModelsForDistributor);
                        break;

                        case "both": // Get vehicle information for distributor
                            do 
                            {
                                Console.WriteLine($"Enter the number of vehicle models for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                model.numOfVehicleModelsForDistributor = int.Parse(Console.ReadLine());
                                if(model.numOfVehicleModelsForDistributor <= 0)
                                    Console.WriteLine("Number of vehicle models cannot be less than 0");
                                else
                                    break;
                            }while(true);
                            
                            VehicleModel[] vehicleModelsForDistributor = new VehicleModel[model.numOfVehicleModelsForDistributor];
                            for(int k=0; k < model.numOfVehicleModelsForDistributor; k++)
                            {
                                VehicleModel vehicleModel = new VehicleModel();

                                Console.WriteLine($"Enter the name of vehicle model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                vehicleModel.ModelName = Console.ReadLine();

                                do
                                {
                                    Console.WriteLine($"Enter the type of vehicle model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                    vehicleModel.ModelType = Console.ReadLine().ToLower();
                                    if(vehicleModel.ModelType != "bike" && vehicleModel.ModelType != "car") 
                                        Console.WriteLine("Vehicle model type should be bike or car");
                                    else
                                        break;
                                }while(true);

                                do
                                {
                                    Console.WriteLine($"Enter the base price of vehicle model {k+1} for distributor {distributor.DistributorName} for company {company.CompanyName}: ");
                                    model.basePrice = decimal.Parse(Console.ReadLine());
                                    if(model.basePrice <= 0 ) 
                                        Console.WriteLine("vehicle model base price cannot be less than 0 or 0");
                                    else
                                        break;
                                }while(true);

                                do 
                                {
                                    Console.WriteLine($"Enter the commision of distributor {distributor.DistributorName} on vehicle {vehicleModel.ModelName}: ");
                                    distributor.Commision = Convert.ToDouble(Console.ReadLine());
                                    if(distributor.Commision < 0 || distributor.Commision > 100)
                                        Console.WriteLine("Commision should be between 0 to 100");
                                    else
                                        vehicleModel.ModelPrice = (model.basePrice * (decimal)distributor.Commision / 100) + model.basePrice;
                                        break;
                                }while(true);
                                
                                vehicleModelsForDistributor[k] = new  VehicleModel(vehicleModel.ModelName, vehicleModel.ModelPrice, vehicleModel.ModelType);
                            }
                            distributorsForCompany[j] = new Distributor(distributor.DistributorName, vehicleModelsForDistributor);
                        break;
                    }
                }
                companies[i] = new Company(company.CompanyName, distributorsForCompany);
            }

            do
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\t\tFind Best Distributor\t");
                Console.WriteLine("------------------------------------");
                // Take input model name to find best distributor
                Console.WriteLine("Enter the model name: ");
                model.modelName = Console.ReadLine();
                
                //Get best distributor
                decimal bestPrice = 0;
                Distributor bestDistributor = new Distributor();
                foreach(Company company in companies)
                {
                    foreach(Distributor distributor in company.Distributors)
                    {
                        foreach(VehicleModel vehicle in distributor.VehicleModels)
                        {
                            if (model.modelName.ToLower() == vehicle.ModelName.ToLower())
                            {
                                if (bestPrice == 0 || bestPrice > vehicle.ModelPrice)
                                {
                                    bestPrice = vehicle.ModelPrice;
                                    bestDistributor = distributor;
                                }
                            }
                        }
                    }
                }
                
                if (bestDistributor == null)
                {
                    Console.WriteLine("Model not found");
                }
                else
                {
                    Console.WriteLine($"The best price for {model.modelName} is {bestPrice} by distributor {bestDistributor.DistributorName}");
                }
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Enter exit to stop or press enter to continue..");
                Console.WriteLine("------------------------------------");
                model.exit = Console.ReadLine().ToLower();
                if (model.exit == "exit")
                    break;
            }while(true);
        }
    }
}