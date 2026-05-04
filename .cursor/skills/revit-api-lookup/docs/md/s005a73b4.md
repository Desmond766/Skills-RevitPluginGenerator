---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnectionType.FindTypeByName(Autodesk.Revit.DB.Document,System.String)
source: html/3c93daf3-82ed-b686-57ff-6e80f06c618e.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnectionType.FindTypeByName Method

Finds the analytical connection type by its name.

## Syntax (C#)
```csharp
public static ElementId FindTypeByName(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the analytical conneciton type is expected.
- **name** (`System.String`) - The name of the expected analytical connection type.

## Returns
The element id of matched analytical connection type, otherwise invalidElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

