# Inquirer

![.NET Core](https://github.com/afucher/Inquirer/workflows/testing/badge.svg)

A collection of common interactive command line user interfaces in C#.

## Examples  
You can find some examples in the [samples](/samples/Samples/Basic) project.

## Inputs
 - Basic Input
 - Numeric Input
 - Confirmation Input
 - List Input
 - Password Input

## Validation
You can set your own valid using the `SetValid` method in the input. It receives an object that must implement the `IValidator` interface.
```csharp
var numbersOnly = new RegexValidator("^[0-9]*$");
ageInput.SetValid(numbersOnly);
```

We already have some validators that you can use:
 - RegexValidator
 - NumericValidator
 - CreditCardNumberValidator
 - EmailValidator
 - DateValidator
 - BooleanValidator

But feel free to implement yours or contribute with more validators 😉

## Running the tests  
Go to folder `src` and run:

```
dotnet test
```

## License  
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details


## Acknowledgments  
Inpired by [SBoundrias/Inquirer.js](https://github.com/SBoudrias/Inquirer.js/)
