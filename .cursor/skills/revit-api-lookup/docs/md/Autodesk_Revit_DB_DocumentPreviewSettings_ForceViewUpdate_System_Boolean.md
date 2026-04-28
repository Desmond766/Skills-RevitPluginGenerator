---
kind: method
id: M:Autodesk.Revit.DB.DocumentPreviewSettings.ForceViewUpdate(System.Boolean)
source: html/b787e706-efb9-22c2-d937-79b8bcc0e2e2.htm
---
# Autodesk.Revit.DB.DocumentPreviewSettings.ForceViewUpdate Method

Sets Revit to update the preview view if necessary.

## Syntax (C#)
```csharp
public void ForceViewUpdate(
	bool forceViewUpdate
)
```

## Parameters
- **forceViewUpdate** (`System.Boolean`) - True to force update of the preview view. False to skip update if necessary (the default).

## Remarks
An update is necessary if the view has never been displayed, or if
 the model has been changed and the view has not been updated or accessed.
 If the preview view has not been updated, the preview may not be properly
 saved. This setting applies only to a single Save operation and is reset to
 false after it is accessed.

