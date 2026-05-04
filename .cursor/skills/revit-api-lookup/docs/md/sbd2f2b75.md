---
kind: method
id: M:Autodesk.Revit.DB.ModelPath.Compare(Autodesk.Revit.DB.ModelPath)
source: html/124239c3-5494-a3eb-fa80-6b6503f1a08a.htm
---
# Autodesk.Revit.DB.ModelPath.Compare Method

Compares this ModelPath with another

## Syntax (C#)
```csharp
public int Compare(
	ModelPath otherPath
)
```

## Parameters
- **otherPath** (`Autodesk.Revit.DB.ModelPath`) - The path to compare against.

## Returns
A signed integer indicating the lexical relationship between
 two ModelPaths. Value is less than zero if this path is less than
 the given path; zero if the two are the same; and more than zero otherwise

## Remarks
The comparison is case-insensitive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

