    Console.Write("Client Name: ");
    string clientName = Console.ReadLine() ?? "";
    Console.Write("Labor Hours: ");
    decimal laborHours = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Material Cost: ");
    decimal materialCost = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Project Type (Small, Medium, Large): ");
    string projectTypeInput = Console.ReadLine() ?? "";

    decimal laborCost = laborHours * Labor.LABOR_RATE;
    
    decimal multiplier;
   
    if (projectTypeInput == "Small")
    {
        multiplier = 1.0m;
    }
    else if (projectTypeInput == "Medium")
    {
        multiplier = 1.5m;
    }
    else if (projectTypeInput == "Large")
    {
        multiplier = 2.0m;
    }
    else
    {
        Console.WriteLine("Invalid project type. Defaulting to Small.");
        multiplier = 1.0m;
    }

    decimal subtotal = laborCost + materialCost * multiplier;

    Console.Write("Do you have a discount percentage? (Press Enter if none): ");
    string discountInput = Console.ReadLine() ?? "";
    decimal discountPercentage = 0m;

    if (!string.IsNullOrWhiteSpace(discountInput) && !decimal.TryParse(discountInput, out discountPercentage))
    {
        Console.WriteLine("Invalid discount. Continuing without a discount.");
        discountPercentage = 0m;
    }

    if (discountPercentage > 0)
    {
        decimal discountAmount = subtotal * (discountPercentage / 100m);
        subtotal -= discountAmount;
    }

    decimal tax = subtotal * Labor.TAX_RATE;
    decimal totalCost = Math.Round(subtotal + tax, 2);
    decimal EstimatedDuration = Math.Ceiling(laborHours / 8);

    decimal projectNumber = new Random().Next(1000, 9999);

//Project estimate display
Console.WriteLine("--------------------------------");
Console.WriteLine("Project Estimate");
Console.WriteLine("--------------------------------");
Console.WriteLine();
Console.WriteLine("Project Number: " + projectNumber);
Console.WriteLine("Client: " + clientName);
Console.WriteLine("Project Type: " + projectTypeInput);
Console.WriteLine("");
Console.WriteLine("Labor Cost: $" + laborCost.ToString("F2"));
Console.WriteLine("Material Cost: $" + materialCost.ToString("F2"));
Console.WriteLine("Subtotal: $" + subtotal.ToString("F2"));
Console.WriteLine("Tax: $" + tax.ToString("F2"));
Console.WriteLine("");
Console.WriteLine("Total Cost: $" + totalCost.ToString("F2"));
Console.WriteLine("");
Console.WriteLine("Estimated Days: " + EstimatedDuration);