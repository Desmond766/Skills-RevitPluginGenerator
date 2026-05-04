---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.NewProjectDocument(Autodesk.Revit.DB.UnitSystem)
source: html/b629d38d-daa3-5109-7e59-6cc12665d832.htm
---
# Autodesk.Revit.ApplicationServices.Application.NewProjectDocument Method

Creates a new project document with no template file specified.

## Syntax (C#)
```csharp
public Document NewProjectDocument(
	UnitSystem unitSystem
)
```

## Parameters
- **unitSystem** (`Autodesk.Revit.DB.UnitSystem`) - The unit system used for the new document.

## Returns
The newly created document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

