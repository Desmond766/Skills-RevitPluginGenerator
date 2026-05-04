---
kind: method
id: M:Autodesk.Revit.DB.SaveAsOptions.SetWorksharingOptions(Autodesk.Revit.DB.WorksharingSaveAsOptions)
source: html/166bb90b-e729-e87c-7ef7-954c240aec34.htm
---
# Autodesk.Revit.DB.SaveAsOptions.SetWorksharingOptions Method

Sets Worksharing options for SaveAs.

## Syntax (C#)
```csharp
public void SetWorksharingOptions(
	WorksharingSaveAsOptions worksharingOptions
)
```

## Parameters
- **worksharingOptions** (`Autodesk.Revit.DB.WorksharingSaveAsOptions`) - Must be Nothing nullptr a null reference ( Nothing in Visual Basic) for a non-workshared model. Allowed to be Nothing nullptr a null reference ( Nothing in Visual Basic) for a workshared model,
 in which case default values for WorksharingSaveAsOptions are used.

