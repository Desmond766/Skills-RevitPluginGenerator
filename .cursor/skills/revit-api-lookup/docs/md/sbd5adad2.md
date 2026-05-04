---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.GetStructuralSection
zh: 族类型、族符号
source: html/99fb2804-0763-d6d1-13e7-7f49ff85fb68.htm
---
# Autodesk.Revit.DB.FamilySymbol.GetStructuralSection Method

**中文**: 族类型、族符号

Gets the structural section from element.

## Syntax (C#)
```csharp
public StructuralSection GetStructuralSection()
```

## Returns
The structural section. Nothing nullptr a null reference ( Nothing in Visual Basic) if the family symbol does not contain a structural section.

## Remarks
Only beams, braces and structural columns can have a structural section.
 To check if the element can have structural section use the [!:Family.HasStructuralSection()] method.

