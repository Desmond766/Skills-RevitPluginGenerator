---
kind: type
id: T:Autodesk.Revit.DB.PartMaker
source: html/ec5be0eb-bf10-0f05-83a4-77daa2cfb0fd.htm
---
# Autodesk.Revit.DB.PartMaker

PartMaker is an element which takes some source elements (e.g., a wall
 with all its layers) and creates one or more Parts out of it. The logic
 according to which these Parts are created is non-trivial and PartMaker
 uses various PartMakerMethods which represents these logics.
 This element manages the strategy to make Part elements for one or more original elements.

## Syntax (C#)
```csharp
public class PartMaker : Element
```

