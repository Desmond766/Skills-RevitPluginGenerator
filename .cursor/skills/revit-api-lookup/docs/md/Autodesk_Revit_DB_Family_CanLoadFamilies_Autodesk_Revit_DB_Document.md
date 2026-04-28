---
kind: method
id: M:Autodesk.Revit.DB.Family.CanLoadFamilies(Autodesk.Revit.DB.Document)
zh: 族
source: html/f9fbccbe-7727-69b5-6253-dcedbbedafde.htm
---
# Autodesk.Revit.DB.Family.CanLoadFamilies Method

**中文**: 族

Checks whether the document is in a state that allows the loading of families.

## Syntax (C#)
```csharp
public static bool CanLoadFamilies(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to check.

## Returns
True if loading of families is allowed, otherwise False.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

