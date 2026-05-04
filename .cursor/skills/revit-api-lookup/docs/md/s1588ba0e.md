---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetReferencesWithDividedSurfaces(Autodesk.Revit.DB.Element)
source: html/4714c725-4863-5e56-e23f-49e207942e02.htm
---
# Autodesk.Revit.DB.DividedSurface.GetReferencesWithDividedSurfaces Method

For a given host element get references to all the faces that host a divided surface

## Syntax (C#)
```csharp
public static IList<Reference> GetReferencesWithDividedSurfaces(
	Element host
)
```

## Parameters
- **host** (`Autodesk.Revit.DB.Element`) - The element that hosts the divided surfaces

## Returns
References that host a divided surface

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

