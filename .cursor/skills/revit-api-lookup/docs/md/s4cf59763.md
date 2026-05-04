---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.CurtainGridFamilyFailures.NonSystemPanelFamiliesCannotBeUsed
source: html/c211feb0-aa5d-7510-9d43-415540931326.htm
---
# Autodesk.Revit.DB.BuiltInFailures.CurtainGridFamilyFailures.NonSystemPanelFamiliesCannotBeUsed Property

Non-system panel families cannot be used for non-rectangular panels. If your panel is simple, create an appropriate panel type derived from the system panel family. If not, try making the panel in the wall or roof rectangular, and then using a panel family of the desired (non-rectangular) shape. The wall will then conform to the non-rectangular shape of the panel.

## Syntax (C#)
```csharp
public static FailureDefinitionId NonSystemPanelFamiliesCannotBeUsed { get; }
```

