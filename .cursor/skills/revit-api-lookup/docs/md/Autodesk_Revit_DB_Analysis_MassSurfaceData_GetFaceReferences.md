---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MassSurfaceData.GetFaceReferences
source: html/a7afead8-f134-96b4-daf6-e2ceee81f3e5.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.GetFaceReferences Method

Gets References to the faces that the MassSurfaceData provides properties for.

## Syntax (C#)
```csharp
public IList<Reference> GetFaceReferences()
```

## Returns
Returns an array of References to Faces that the MassSurfaceData provides properties for.

## Remarks
The results are always references to Faces. The Reference Type should be REFERENCE_TYPE_SURFACE.
 Currently Revit improperly reports it as REFERENCE_TYPE_NONE.

