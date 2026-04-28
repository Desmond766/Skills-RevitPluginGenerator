---
kind: type
id: T:Autodesk.Revit.DB.Analysis.ConceptualSurfaceType
source: html/b79ddf97-2888-ceda-a2c4-222dab08163e.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualSurfaceType

This element represents a conceptual BIM object category to assign to faces in Mass geometries.
 There is one ConceptualSurfaceType element for each of the Mass Surface Subcategories.
 for serialization

## Syntax (C#)
```csharp
public class ConceptualSurfaceType : Element
```

## Remarks
When Conceptual Energy Analysis is enabled in Revit Projects, massing faces will be assigned
 to the subcategories of Mass category that these ConceptualSurfaceType's are associated with.
 A default ConceptualConstructionType is associated with the ConceptualSurfaceType. This
 default ConceptualConstructionType is assigned to Mass faces with the corresponding subcategory.
 Changing the default ConceptualConstructionType associated with the ConceptualSurfaceType
 will update the ConceptualConstruction type for all Mass faces of that subcategory which the
 user has not specifically provided an override value for.

