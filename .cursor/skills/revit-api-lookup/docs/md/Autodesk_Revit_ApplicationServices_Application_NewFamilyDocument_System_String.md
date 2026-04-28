---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.NewFamilyDocument(System.String)
source: html/bc292c96-bc2b-04ab-726b-575d92be61fd.htm
---
# Autodesk.Revit.ApplicationServices.Application.NewFamilyDocument Method

New family document, including family, titleblock, and annotation symbol

## Syntax (C#)
```csharp
public virtual Document NewFamilyDocument(
	string templateFileName
)
```

## Parameters
- **templateFileName** (`System.String`) - The template file name.

## Remarks
This command corresponds to File->New->Family.../TitleBlock.../Annotation Symbol....

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'templateFileName' is Nothing nullptr a null reference ( Nothing in Visual Basic) or an empty string.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the new family document cannot be created.

