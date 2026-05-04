---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.GenericMEPFailures.InlineEndoflineMismatch
source: html/1ffefe1e-9331-e2e7-5437-60983deea1d6.htm
---
# Autodesk.Revit.DB.BuiltInFailures.GenericMEPFailures.InlineEndoflineMismatch Property

[Element Name]: It is not possible to calculate the flow since there is inline equipment that is configured as end of line.
 Please check equipment in this system and make sure that the equipment connectors used inline have a global system classification and a calculated flow configuration.
 Global equipment connectors used inline should always be linked to each other.

## Syntax (C#)
```csharp
public static FailureDefinitionId InlineEndoflineMismatch { get; }
```

