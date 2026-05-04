---
kind: enumMember
id: F:Autodesk.Revit.DB.FamilyInstanceReferenceType.StrongReference
enum: Autodesk.Revit.DB.FamilyInstanceReferenceType
source: html/ab424c61-4b80-9dcd-3f9a-7b35fa670edf.htm
---
# Autodesk.Revit.DB.FamilyInstanceReferenceType.StrongReference

Reference plane whose "Is Reference" parameter is set to "Strong Reference", or reference line whose "Reference" parameter is set to "Strong Reference".
 There may be multiple such reference planes and lines in the family.
 These references are not stable: if there is a dimension to such reference, and the instance's family is replaced,
 the dimension is not guaranteed to survive.

