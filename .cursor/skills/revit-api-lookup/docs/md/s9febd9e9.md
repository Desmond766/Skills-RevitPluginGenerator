---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.SetFormula(System.String)
source: html/7974796f-5771-6640-ce74-0be23eab58d0.htm
---
# Autodesk.Revit.DB.GlobalParameter.SetFormula Method

Sets a formula expression for this parameter.

## Syntax (C#)
```csharp
public void SetFormula(
	string expression
)
```

## Parameters
- **expression** (`System.String`) - Valid formula string.

## Remarks
An assigned expression will compute the parameter's actual value.
 In order to set a formula, the global parameter must be non-reporting. Therefore
 a reporting parameter must be changed to non-reporting first before assigning a formula.
Value of the evaluated formula must be compatible with the value-type of the parameter.
 For example, it is permitted to use Integer parameters in a formula assigned to
 a Double ( Number ) parameter, or vice versa. It is not allowed, however, to use
 Length or Angle arguments in a formula in a parameter of which type is ether
 Integer or Number . To test whether a formula is valid for a global parameter,
 the method IsValidFormula(String) can be used.
An empty string can be used to remove an existing formula. When a formula is removed,
 the parameter retains its value as it was previously computed using the formula.
Formulas may include all standard arithmetic operations and logical operations (as functions and ,
 or , not .) Input to logical operations must be Boolean values (parameters of YesNo type).
 Consequently, arithmetic operations can be applied to numeric values only. While there are no operations
 supported for string (text) arguments, strings can be used as results of a logical If operation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given expression argument is not valid as a formula for this parameter.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This is a non-reporting global parameter. As such it does not allow the current operation.

