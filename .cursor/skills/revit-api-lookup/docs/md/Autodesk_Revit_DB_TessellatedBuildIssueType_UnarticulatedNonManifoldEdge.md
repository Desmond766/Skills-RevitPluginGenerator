---
kind: enumMember
id: F:Autodesk.Revit.DB.TessellatedBuildIssueType.UnarticulatedNonManifoldEdge
enum: Autodesk.Revit.DB.TessellatedBuildIssueType
source: html/b9f37bb0-1c2b-0fe9-a4e8-5a49d2b9b7ac.htm
---
# Autodesk.Revit.DB.TessellatedBuildIssueType.UnarticulatedNonManifoldEdge

An input face is mising an edge conecting two non-adjacent vertices
 from its boundaries, which are adjacent in the boundaries of
 some other face(s). If such an edge would be added, it would
 split the face and result in 'NonManifoldEdge' or other issues.
 Associated numbers are indices of a face which misses an edge
 and indices of one or two faces in which boundaries such edge is
 present.

