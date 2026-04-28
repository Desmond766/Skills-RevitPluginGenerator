---
kind: property
id: P:Autodesk.Revit.DB.WorksharingSaveAsOptions.SaveAsCentral
source: html/f0b5d969-3e86-b433-e2f8-a01292738c85.htm
---
# Autodesk.Revit.DB.WorksharingSaveAsOptions.SaveAsCentral Property

Whether to save the new model as a central instead of local model.
 True: save as a central model.
 Default is false: save as a local model.

## Syntax (C#)
```csharp
public bool SaveAsCentral { get; set; }
```

## Remarks
Must be true for a model where the model has not yet been saved as a central
 after either worksharing has just been enabled
 or the model was opened detached from central
 and .

