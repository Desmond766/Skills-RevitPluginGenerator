---
kind: method
id: M:Autodesk.Revit.DB.Steel.SteelElementProperties.GetSteelElementProperties(Autodesk.Revit.DB.Element)
source: html/b7ec1409-3999-3af0-9db6-c1373a04f892.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties.GetSteelElementProperties Method

Get SteelElementProperties for the input element if they exist.

## Syntax (C#)
```csharp
public static SteelElementProperties GetSteelElementProperties(
	Element pElement
)
```

## Parameters
- **pElement** (`Autodesk.Revit.DB.Element`) - The element from which we try to obtain SteelElementProperties.

## Remarks
If the input element doesn't have steel informations than it retuns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

