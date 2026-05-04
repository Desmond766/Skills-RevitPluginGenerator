---
kind: property
id: P:Autodesk.Revit.DB.ViewSheetSet.ViewOrganizationId
source: html/f8d31451-ddb8-06e3-6c5f-87dff0132645.htm
---
# Autodesk.Revit.DB.ViewSheetSet.ViewOrganizationId Property

ElementId to the BrowserOrganization for non-sheet views.

## Syntax (C#)
```csharp
public virtual ElementId ViewOrganizationId { get; set; }
```

## Remarks
Ignored when [!:Autodesk::Revit::DB::PrintSetup::IsAutomatic] is False false false ( False in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the ElementId does not reference to BrowserOrganization , or the target type of BrowserOrganization is incompatible.

