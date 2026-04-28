---
kind: method
id: M:Autodesk.Revit.DB.OpenOptions.SetOpenWorksetsConfiguration(Autodesk.Revit.DB.WorksetConfiguration)
source: html/88de72a4-cf23-c2e7-7b38-acadc45591e7.htm
---
# Autodesk.Revit.DB.OpenOptions.SetOpenWorksetsConfiguration Method

Sets the object used to configure the worksets to open when the model is opened.

## Syntax (C#)
```csharp
public void SetOpenWorksetsConfiguration(
	WorksetConfiguration openConfiguration
)
```

## Parameters
- **openConfiguration** (`Autodesk.Revit.DB.WorksetConfiguration`) - The options. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all user-created worksets will be opened.

## Remarks
These options are ignored for non-workshared models.

