---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarShapeDefinesHooks
source: html/dac8f11f-7001-41a2-5b51-5d619a4e2231.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarShapeDefinesHooks Property

Hooks are defined by Rebar Shape of Rebar element. Can be changed if document contains no rebars, area reinforcements and path reinforcements.

## Syntax (C#)
```csharp
public bool RebarShapeDefinesHooks { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more Rebar elements.
 -or-
 When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more AreaReinforcement or PathReinforcement
 elements.
 -or-
 When setting this property: Cannot change the RebarShapeDefinesHooks property in these settings because the document contains one or more RebarContainer elements.
 the document contains one or more RebarContainer elements.

