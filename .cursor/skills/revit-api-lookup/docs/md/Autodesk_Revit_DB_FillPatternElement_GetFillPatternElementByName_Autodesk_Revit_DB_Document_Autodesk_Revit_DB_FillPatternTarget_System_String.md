---
kind: method
id: M:Autodesk.Revit.DB.FillPatternElement.GetFillPatternElementByName(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FillPatternTarget,System.String)
source: html/bfb4c482-ee62-2ab3-9528-657f7b0096ce.htm
---
# Autodesk.Revit.DB.FillPatternElement.GetFillPatternElementByName Method

Retrieves the FillPatternElement by its name.

## Syntax (C#)
```csharp
public static FillPatternElement GetFillPatternElementByName(
	Document document,
	FillPatternTarget target,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to retrieve the FillPatternElement.
- **target** (`Autodesk.Revit.DB.FillPatternTarget`) - The FillPatternTarget of the FillPatternElement.
- **name** (`System.String`) - The name of the FillPatternElement.

## Returns
The FillPatternElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - target must be Model or Drafting.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

