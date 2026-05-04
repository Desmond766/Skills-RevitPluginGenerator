---
kind: type
id: T:Autodesk.Revit.DB.ParameterValueProvider
source: html/5978eb2a-4598-f458-1504-80caff09cf7c.htm
---
# Autodesk.Revit.DB.ParameterValueProvider

Gets the value of a parameter from any element passed to GetStringValue,
 GetDoubleValue, GetIntegerValue, or GetElementIdValue.

## Syntax (C#)
```csharp
public class ParameterValueProvider : FilterableValueProvider
```

## Remarks
For any parameter, only one of isStringValueSupported, isDoubleValueSupported,
 isIntegerValueSupported, isElementIdValueSupported will return true. No attempt
 to convert between types is made. For example, calling GetStringValue, passing
 the identifier of a numeric-typed parameter will give an empty string. No
 exception will be thrown, and ParameterValueProvider will not attempt to convert
 the numeric value to a string. If an element doesn't have the requested parameter or the element's parameter doesn't have a valid value,
 ParameterValueProvider will attempt to get the parameter value from the element's type -
 see GetTypeId () () () .

