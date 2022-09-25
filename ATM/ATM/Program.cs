using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for using our sercives");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("6475726375873622", 1234, "Erik", "Enander", 150.35));
        cardHolders.Add(new cardHolder("8475383587r73745", 1762, "Patrik", "Andersson", 1352.35));
        cardHolders.Add(new cardHolder("1238398625961573", 5743, "Simon", "Titze", 847.23));
        cardHolders.Add(new cardHolder("4328957203485821", 8636, "Kajsa", "Larsson", 164));
        cardHolders.Add(new cardHolder("0243651632745639", 1257, "Morgan", "Persson", 3755));
        cardHolders.Add(new cardHolder("1236574290465626", 4793, "Anna", "Petersson", 3460.35));

        // Promp user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against Database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again or contact your bank"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again or contact your bank"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against Database
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrent pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrent pin. Please try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int options = 0;
        do
        {
            printOptions();
            try
            {
                options = int.Parse(Console.ReadLine());
            }
            catch { }
            if(options == 1) { deposit(currentUser); }
            else if(options == 2) { withdraw(currentUser); }
            else if(options == 3) { balance(currentUser); }
            else if(options == 4) { break; }
            else { options = 0; }
        }
        while (options != 4);
        Console.WriteLine("Thank you! Have a nice day");
    }
}