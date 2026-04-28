---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.NewProjectTemplateDocument(System.String)
source: html/15d7ed8e-6281-e2b7-b875-657f205a6c1f.htm
---
# Autodesk.Revit.ApplicationServices.Application.NewProjectTemplateDocument Method

New project template document

## Syntax (C#)
```csharp
public virtual Document NewProjectTemplateDocument(
	string templateFilename
)
```

## Parameters
- **templateFilename** (`System.String`) - The template file name.

## Remarks
This command corresponds to New->Project->Project Template command in the user-interface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'templateFileName' is Nothing nullptr a null reference ( Nothing in Visual Basic) or an empty string.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the project template document cannot be created.

