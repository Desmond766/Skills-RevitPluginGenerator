---
kind: method
id: M:Autodesk.Revit.DB.Floor.GetDefaultFloorType(Autodesk.Revit.DB.Document,System.Boolean)
zh: 楼板、板、地板
source: html/3eebff6a-ccfa-d4ab-fcf8-239d4d2ec8de.htm
---
# Autodesk.Revit.DB.Floor.GetDefaultFloorType Method

**中文**: 楼板、板、地板

Returns id of default floor type.

## Syntax (C#)
```csharp
public static ElementId GetDefaultFloorType(
	Document document,
	bool isFoundation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **isFoundation** (`System.Boolean`) - True to return id of foundation floor type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

