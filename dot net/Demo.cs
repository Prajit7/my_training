class Item
{
    public int Id { get; set; }
    public string Perticulars { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string particulars, decimal unitPrice, int quantity)
    {
        Id = id;
        Perticulars = particulars;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}


class ItemizedBill
{
    private List<Item> _items;
    public Bill Bill { get; private set; }
    public string CustomerName { get; private set; }

    public ItemizedBill(string customerName)
    {
        CustomerName = customerName;
        _items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void GenerateBill(int billNo, DateTime billDate)
    {
        decimal totalCost = _items.Sum(item => item.UnitPrice * item.Quantity);
        Bill = new Bill(billNo, billDate, CustomerName, totalCost);
    }

    public void PrintBill()
    {
        Console.WriteLine("Bill No: " + Bill.BillNo);
        Console.WriteLine("Bill Date: " + Bill.BillDate);
        Console.WriteLine("Bill Holder: " + Bill.BillHolder);
        Console.WriteLine("Items: ");
        foreach (var item in _items)
        {
            Console.WriteLine("Id: " + item.Id);
            Console.WriteLine("Particulars: " + item.Perticulars);
            Console.WriteLine("Unit Price: " + item.UnitPrice);
            Console.WriteLine("Quantity: " + item.Quantity);
        }
        Console.WriteLine("Total Amount: " + Bill.BillAmount);
    }
}
class ItemizedBill
{
    private List<Item> _items;
    public Bill Bill { get; private set; }
    public string CustomerName { get; private set; }

    public ItemizedBill(string customerName)
    {
        CustomerName = customerName;
        _items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void GenerateBill(int billNo, DateTime billDate)
    {
        decimal totalCost = _items.Sum(item => item.UnitPrice * item.Quantity);
        Bill = new Bill(billNo, billDate, CustomerName, totalCost);
    }

    public void PrintBill()
    {
        Console.WriteLine("Bill No: " + Bill.BillNo);
        Console.WriteLine("Bill Date: " + Bill.BillDate);
        Console.WriteLine("Bill Holder: " + Bill.BillHolder);
        Console.WriteLine("Items: ");
        foreach (var item in _items)
        {
            Console.WriteLine("Id: " + item.Id);
            Console.WriteLine("Particulars: " + item.Perticulars);
            Console.WriteLine("Unit Price: " + item.UnitPrice);
            Console.WriteLine("Quantity: " + item.Quantity);
        }
        Console.WriteLine("Total Amount: " + Bill.BillAmount);
    }
}

//create object of itemized bill
ItemizedBill itemizedBill = new ItemizedBill("John Doe");

//add items to the bill
itemizedBill.AddItem(new Item(1, "Apple", 0.5M, 10));
itemizedBill.AddItem(new Item(2, "Banana", 0.3M, 20));
itemizedBill.AddItem(new Item(3, "Orange", 0.4M, 15));

//generate bill

//
//
//generate bill
