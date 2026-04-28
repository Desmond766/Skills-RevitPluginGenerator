---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCData.CreateLogicalOfType(Autodesk.Revit.DB.IFC.IFCLogical,System.String)
source: html/8d483b72-069f-183c-3dc1-6d14429c086d.htm
---
# Autodesk.Revit.DB.IFC.IFCData.CreateLogicalOfType Method

Creates a logical data object of the specified type.

## Syntax (C#)
```csharp
public static IFCData CreateLogicalOfType(
	IFCLogical value,
	string typeName
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.IFC.IFCLogical`) - The IFCLogical value.
- **typeName** (`System.String`) - The type name.

## Returns
The IFCData object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

