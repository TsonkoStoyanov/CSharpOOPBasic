using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> childrens;

    public Person(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
        this.Childrens = new List<Person>();
        this.Parents = new List<Person>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public List<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Person> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
