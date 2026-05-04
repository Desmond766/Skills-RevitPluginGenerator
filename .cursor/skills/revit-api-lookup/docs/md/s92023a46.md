---
kind: property
id: P:Autodesk.Revit.DB.SynchronizeWithCentralOptions.SaveLocalAfter
source: html/636d5979-3eca-0425-2ef4-352452daeeaf.htm
---
# Autodesk.Revit.DB.SynchronizeWithCentralOptions.SaveLocalAfter Property

True means to save local after saving changes to central. True by default.
 Silently ignored if the model in the current session is central rather than local.

## Syntax (C#)
```csharp
public bool SaveLocalAfter { get; set; }
```

## Remarks
It is recommended practice to save local after SWC because otherwise local becomes incompatible with central.

