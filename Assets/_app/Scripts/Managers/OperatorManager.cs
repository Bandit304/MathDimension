using _app.Scripts.Operators;
using UnityEngine;

public class OperatorManager : MonoBehaviour
{
    // For now we are only storing one operation but future levels will introduce more
    private CustomOperator op;
    
    // OperatorManager is a singleton, it stores and utilizes the stored equations when they are needed
    // so we don't want multiple
    private static OperatorManager _instance;
    public static OperatorManager Instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            // this destroys the current instance if another one exists
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void GenerateSimpleOperator()
    {
        op = new SimpleOperator();
    }

    public double Calculate(double x, double y)
    {
        return op.RunCalculation(x, y);
    }

    public string GetName()
    {
        return op.name;
    }

    public string GetSymbol()
    {
        return op.symbol;
    }
}
