---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarShapeDefinesEndTreatments
source: html/1961031f-e056-da42-215f-bf7d3ddcd530.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarShapeDefinesEndTreatments Property

End Treatments are defined by Rebar Shape of Rebar element. Can be changed if document contains no rebars, area reinforcements and path reinforcements.

## Syntax (C#)
```csharp
public bool RebarShapeDefinesEndTreatments { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more Rebar elements.
 -or-
 When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more AreaReinforcement or PathReinforcement
 elements.
 -or-
 When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more RebarContainer elements.
 the document contains one or more RebarContainer elements.

