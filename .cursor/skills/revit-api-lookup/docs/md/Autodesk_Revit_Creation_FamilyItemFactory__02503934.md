---
kind: type
id: T:Autodesk.Revit.Creation.FamilyItemFactory
source: html/a7622967-1381-c17f-ed04-1ebe40da0440.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory

The Family Item Factory object is used to create new instances of elements within the
Autodesk Revit Family.

## Syntax (C#)
```csharp
public class FamilyItemFactory : ItemFactoryBase
```

## Remarks
The Family Item Factory object is a utility object that is used to create new
instances of elements within the Autodesk Revit Family Document. This object should be used to 
create elements instead of using New. This
object ensures that the elements created are added to the family document correctly.

