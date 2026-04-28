---
kind: method
id: M:Autodesk.Revit.DB.LinePatternElement.GetLinePatternElementByName(Autodesk.Revit.DB.Document,System.String)
source: html/3b747951-4e30-6ad1-4ff7-02557d8ff691.htm
---
# Autodesk.Revit.DB.LinePatternElement.GetLinePatternElementByName Method

Retrieves the LinePatternElement by its name.

## Syntax (C#)
```csharp
public static LinePatternElement GetLinePatternElementByName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to retrieve the LinePatternElement.
- **name** (`System.String`) - The name of the LinePatternElement.

## Returns
The LinePatternElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

