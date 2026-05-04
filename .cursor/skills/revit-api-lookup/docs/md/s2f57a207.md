---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.Contains(System.String)
source: html/dc950462-3260-64e6-a04f-eb3c2e0266d7.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.Contains Method

A quick check whether a definition already exists in the library. Checks for stored geometry objects only.

## Syntax (C#)
```csharp
public bool Contains(
	string id
)
```

## Parameters
- **id** (`System.String`) - Definition id

## Returns
True if a geometry definition exists, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

