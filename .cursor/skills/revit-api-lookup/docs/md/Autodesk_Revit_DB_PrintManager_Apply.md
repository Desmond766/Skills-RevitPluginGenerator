---
kind: method
id: M:Autodesk.Revit.DB.PrintManager.Apply
source: html/b0f3b473-5226-e34e-0d1d-8d2ed296896c.htm
---
# Autodesk.Revit.DB.PrintManager.Apply Method

Apply the local print settings to global for all documents.

## Syntax (C#)
```csharp
public void Apply()
```

## Remarks
This method will change the settings for the current printer to match what is set in the 
Print Manager. When the user attempts to print with this printer in the future, the changes
made by the API session will be visible.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this operation is not allowed in the current application mode,
or the print resource is occupied by others.

