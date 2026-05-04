---
kind: type
id: T:Autodesk.Revit.DB.IExportContext2D
source: html/a4578846-6ecf-e354-668d-96d8ef5d1a32.htm
---
# Autodesk.Revit.DB.IExportContext2D

An interface that is used in custom export to export 2D views of a Revit model.

## Syntax (C#)
```csharp
public interface IExportContext2D : IExportContextBase
```

## Remarks
An instance of a class that implements this interface is passed in as a
 parameter of the CustomExporter constructor.
 The interface methods are then called at times of drawing entities that are
 currently visible in the view being exported. 
 With this type of export context used to perform a custom export,
 Revit will traverse the model and output the model's geometry
 as if in the process of regular displaying or exporting a 2D View.
 It means that any geometry which is visible in an open view
 (taking any current visibility setting applicable to the view)
 will be processed and output.
 Optionally, annotation objects are also output. 
 Note 1. Curves passed to calls OnFaceEdge2D(FaceEdgeNode) and OnFaceSilhouette2D(FaceSilhouetteNode) may be partially duplicating each other.
Note 2. If element E is a FamilyInstance and it contains an imported instance then:
 between the calls to OnElementBegin2D/OnElementEnd2D for element E there will be calls to OnInstanceBegin/OnInstanceEnd with the "node" argument pointing to the element with its symbol being of category BuiltInCategories.OST_ImportObjectStyles all geometry exported for the element E has to be additionally subject to the transform T=E.GetTotalTransform()

