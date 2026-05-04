---
kind: type
id: T:Autodesk.Revit.DB.WorksetPreview
source: html/5091902c-a286-eb9e-d65b-3d421d741c69.htm
---
# Autodesk.Revit.DB.WorksetPreview

Represents an accessor for workset data which can be obtained from an unopened document.

## Syntax (C#)
```csharp
public class WorksetPreview : IDisposable
```

## Remarks
As a base class of Workset, this class has limited access to data. WorksetPreviews are obtained from
 WorksharingUtils.GetUserWorksetInfo() from an unopened document.

