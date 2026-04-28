---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeLibrary.ContainsType(System.String)
source: html/ebad7e8c-6037-401e-fa65-9957e5904a7b.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.ContainsType Method

A quick check whether a definition type already exists in the library. Checks for type objects only.

## Syntax (C#)
```csharp
public bool ContainsType(
	string name
)
```

## Parameters
- **name** (`System.String`) - Definition id

## Returns
True if a geometry definition exists, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

