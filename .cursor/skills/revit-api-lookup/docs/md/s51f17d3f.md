---
kind: property
id: P:Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.IsActive
source: html/b8f370dd-3231-7a0e-8005-0f0c24fba274.htm
---
# Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.IsActive Property

Identifies if the EditScope is active. In other words, the EditScope has started but not committed/canceled yet.

## Syntax (C#)
```csharp
public bool IsActive { get; }
```

## Remarks
Starting the edit scope is not permitted when it is active.
 Canceling/committing is not allowed when the edit scope is not active.

