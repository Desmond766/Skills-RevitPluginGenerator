---
kind: method
id: M:Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.Cancel
source: html/d11009db-d724-167f-04e6-0e7c5527c176.htm
---
# Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.Cancel Method

Cancels the edit scope.

## Syntax (C#)
```csharp
public void Cancel()
```

## Remarks
All the changes made after starting the EditScope will be discarded.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - EditScope is not active. EditScope can only be committed or cancelled when it is active.
 -or-
 EditScope cannot be closed, there is no opened transaction.

