---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.GetFaceRegions(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/4dd110d1-ee73-928b-2b97-3ddd51d0591c.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.GetFaceRegions Method

Gets the FaceRegions in the existing face.

## Syntax (C#)
```csharp
public static IList<Reference> GetFaceRegions(
	Document cda,
	Reference referenceOfFace
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The Document.
- **referenceOfFace** (`Autodesk.Revit.DB.Reference`) - The Reference of the existing face.

## Returns
The FaceRegions in the existing face, or an empty collection if no FaceRegions are found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Reference is not a Face Reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

