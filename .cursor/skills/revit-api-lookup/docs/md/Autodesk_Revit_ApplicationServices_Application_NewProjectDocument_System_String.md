---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.NewProjectDocument(System.String)
source: html/54a1c1b6-49cc-2d35-a5e9-09b1a8442adf.htm
---
# Autodesk.Revit.ApplicationServices.Application.NewProjectDocument Method

New project document

## Syntax (C#)
```csharp
public virtual Document NewProjectDocument(
	string templateFileName
)
```

## Parameters
- **templateFileName** (`System.String`) - The template file name.

## Remarks
This command corresponds to New->Project command in the user-interface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'templateFileName' is Nothing nullptr a null reference ( Nothing in Visual Basic) or an empty string.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the new project document cannot be created.

