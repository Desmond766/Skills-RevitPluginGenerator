---
kind: property
id: P:Autodesk.Revit.DB.ViewSheetSet.SheetOrganizationId
source: html/a28d4e62-17bc-96c2-4ebb-d6a9b96afb1d.htm
---
# Autodesk.Revit.DB.ViewSheetSet.SheetOrganizationId Property

ElementId to the BrowserOrganization for sheets.

## Syntax (C#)
```csharp
public virtual ElementId SheetOrganizationId { get; set; }
```

## Remarks
Ignored when [!:Autodesk::Revit::DB::PrintSetup::IsAutomatic] is False false false ( False in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the ElementId does not reference to BrowserOrganization , or the target type of BrowserOrganization is incompatible.

