---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.GetRebarHostData(Autodesk.Revit.DB.Element)
source: html/17db56d4-89cb-edda-fb5e-ab97883dc922.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.GetRebarHostData Method

Gets a RebarHostData object referring to the specified
 rebar host element.

## Syntax (C#)
```csharp
public static RebarHostData GetRebarHostData(
	Element host
)
```

## Parameters
- **host** (`Autodesk.Revit.DB.Element`) - An element to host rebar.

## Returns
A RebarHostData object, or Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) for elements that cannot ever be rebar hosts,
 such as levels.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

