---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerType.GetOrCreateRebarContainerType(Autodesk.Revit.DB.Document,System.String)
source: html/741c9232-eb1a-c082-3433-04bdbf630766.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerType.GetOrCreateRebarContainerType Method

Creates or returns a RebarContainerType object with a given name.

## Syntax (C#)
```csharp
public static ElementId GetOrCreateRebarContainerType(
	Document aDoc,
	string name
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - Name of the type.

## Returns
The type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

