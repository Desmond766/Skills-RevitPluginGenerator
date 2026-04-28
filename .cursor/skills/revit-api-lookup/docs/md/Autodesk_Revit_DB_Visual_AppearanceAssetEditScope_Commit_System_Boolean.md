---
kind: method
id: M:Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.Commit(System.Boolean)
source: html/320a2602-0a2c-df20-01dc-2ede9d62afdd.htm
---
# Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.Commit Method

Finishes the edit scope.

## Syntax (C#)
```csharp
public void Commit(
	bool updateOpenViews
)
```

## Parameters
- **updateOpenViews** (`System.Boolean`) - When true, force update of the open views.

## Remarks
All the changes made after starting the EditScope will be committed. Changes will be merged into one transaction.
 If the appearance asset element is used in one or more materials, they will be updated to match any changes made.
 Open views may not redraw after changes. View update can be forced with the input argument, but doing so can be an expensive operation.
 Consider using false if immediate update is not needed or if multiple calls to this method are used in a loop.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - EditScope is not active. EditScope can only be committed or cancelled when it is active.
 -or-
 EditScope cannot be closed, there is no opened transaction.
 -or-
 The editable asset is not valid.

