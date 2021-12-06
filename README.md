[![Build Status](https://fluxera.visualstudio.com/Foundation/_apis/build/status/GitHub/Fluxera.Guard?branchName=main)](https://fluxera.visualstudio.com/Foundation/_build/latest?definitionId=57&branchName=main)

# Guard

An extendable guard implementation.

A guard clause helps to check inputs for validity and fails immediately if any invalid inputs are found.
The guard clauses are implemented as extension methods on the marker ```IGuard```. This way custom guards
can be added to the available default guard clauses.

## Usage

Check inputs of methods and constructors and fail early. The guard will fail with an exception if the input is not valid.

```c#
public void UpdateCustomer(Customer customer)
{
    Guard.Against.Null(customer, nameof(customer));

    // Update the customer...
}
```

Check inputs constructors, fail early or assign the value. The guard will fail with an exception if the input is not valid 
or return the input value if it is valid.

```c#
public class Customer
{
    public Customer(string name, decimal credit)
    {
        this.Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        this.Credit = Guard.Against.Negative(credit, nameof(credit));
    }

    public string Name { get; }

    public decimal Credit { get; }
}
```

Create your own guards by adding extension methods on ```IGuard```. To create the exception to throw
you can use one of the helpers from the ```ExceptionHelpers``` class. This helpers make sure that
the correct constructors are used and the parameter name is set correctly.

```c#
// ReSharper disable once CheckNamespace
namespace Fluxera.Guard
{
    // Note: Using the namespace 'Fluxera.Guard' will ensure that your
    //       custom guard is available throughout your projects.

    using JetBrains.Annotations;
    using static ExceptionHelpers;

    public static class CustomGuardExtensions
    {
        public static void Hello(this IGuard guard, string input, string parameterName, string? message = null)
        {
            if(input.ToLower() == "hello")
            {
                throw CreateArgumentException(parameterName, message);
            }
        }
    }
}
```

## Available Guards

- **```Guard.Against.Null```**
    - Throws an ```ArgumentNullException``` if the input is ```null```.
- **```Guard.Against.Default```**
    - Throws an ```ArgumentException``` if the input is ```default```. 
- **```Guard.Against.NullOrEmpty```**
    - Throws an ```ArgumentNullException``` if the input string is ```null```.
    - Throws an ```ArgumentException``` if the input string is ```string.Empty```.
    - Throws an ```ArgumentNullException``` if the input enumerable is ```null```.
    - Throws an ```ArgumentException``` if the input enumerable is empty.
    - Throws an ```ArgumentNullException``` if the input nullable guid is ```null```.
    - Throws an ```ArgumentException``` if the input nullable guid is ```Guid.Empty```.
- **```Guard.Against.NullOrWhiteSpace```**
    - Throws an ```ArgumentNullException``` if the input string is ```null```.
    - Throws an ```ArgumentException``` if the input string is ```string.Empty``` or whitespace-only.
- **```Guard.Against.Empty```**
    - Throws an ```ArgumentException``` if the input guid is ```Guid.Empty```.
- **```Guard.Against.Negative```**
    - Throws an ```ArgumentException``` if the input is < 0.
- **```Guard.Against.Zero```**
    - Throws an ```ArgumentException``` if the input is == 0.
- **```Guard.Against.NegativeOrZero```**
    - Throws an ```ArgumentException``` if the input is <= 0.
- **```Guard.Against.OutOfRange```**
    - Throws an ```ArgumentOutOfRangeException``` if the input is not within a given range.
    - Throws an ```InvalidEnumArgumentException``` if the input is not a defined enum value.
- **```Guard.Against.False```**
    - Throws an ```ArgumentException``` if the input is ```false```.
- **```Guard.Against.True```**
    - Throws an ```ArgumentException``` if the input is ```true```.
- **```Guard.Against.InvalidInput```**
    - Throws an ```ArgumentException``` if the input doesn't satisfy a predicate.
- **```Guard.Against.InvalidFormat```**
    - Throws an ```ArgumentException``` if the input doesn't match a regex pattern.

