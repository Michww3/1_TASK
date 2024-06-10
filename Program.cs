using System.Collections;

ResidentCollection residentCollection = new ResidentCollection();
Student student = new Student { passportNumber = "S123" };
Pensioner pensioner = new Pensioner { passportNumber = "P123" };
Worker worker = new Worker { passportNumber = "W123" };

residentCollection.AddToCollection(student);
residentCollection.AddToCollection(pensioner);
residentCollection.AddToCollection(worker);
residentCollection.Remove(student);
Console.WriteLine(residentCollection.Contains(pensioner));
Console.WriteLine(residentCollection.ReturnLast());
//residentCollection.Clear();
foreach (Resident resident in residentCollection)
{
    Console.WriteLine(resident.passportNumber);
}

public abstract class Resident
{
    public string passportNumber { get; set; }
}

public class Student : Resident;

public class Pensioner : Resident;

public class Worker : Resident;

public class ResidentCollection
{
    private ArrayList  list = new ArrayList();

    public void AddToCollection(Resident resident)
    {
        if  (list.Cast<Resident>().Any(c => c.passportNumber == resident.passportNumber))
        {
            Console.WriteLine("Collection already has this person");
            return;
        }

        if (resident is Pensioner)
        {
            list.Insert(0,resident);
        }
        else list.Add(resident);
    }

    public void RemoveAtStart()
    {
        if (list.Count > 0)
        {
            list.RemoveAt(0);
            Console.WriteLine("Citizen removed from the beginning of the collection.");
        }
    }

    public void Remove(Resident resident)
    {
        if (list.Contains(resident))
        {
            list.Remove(resident);
            Console.WriteLine("Resident removed from the collection.");
        }
    }

    public bool Contains(Resident resident)
    {
        return list.Contains(resident);
    }

    public (Resident, int) ReturnLast()
    {
        int index = list.Count - 1;
        Resident lastResident = (Resident)list[index];
        return (lastResident, index);
    }

    public void Clear ()
    {
        list.Clear();
    }

    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }
}

