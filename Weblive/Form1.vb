Imports System.IO
Imports FastColoredTextBoxNS
Class Form1
    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        Dim formprincipal As New Principal
        Dim fdialog As New FolderBrowserDialog
        Dim result = fdialog.ShowDialog()

        If result = DialogResult.OK Then
            Dim dir As New DirectoryInfo(fdialog.SelectedPath)
            If dir.Exists Then
                Dim tree As New TreeNode(dir.Name)
                tree.Tag = dir
                GetDir(dir.GetDirectories, tree)
                GetFile(dir.GetFiles, tree)
                formprincipal.TreeView1.Nodes.Add(tree)
                formprincipal.Show()
            End If
        End If

    End Sub
    Private Sub GetDir(subdirs As DirectoryInfo(), nodetoadd As TreeNode)
        Dim aNode As TreeNode
        For Each subdir As DirectoryInfo In subdirs
            aNode = New TreeNode(subdir.Name, 0, 0)
            aNode.Tag = subdir
            Dim subsubdir = subdir.GetDirectories()
            Dim files = subdir.GetFiles()
            If subsubdir.Length > 0 Then
                GetDir(subsubdir, aNode)
            End If
            If files.Length > 0 Then
                GetFile(files, aNode)
            End If
            nodetoadd.Nodes.Add(aNode)
        Next
    End Sub
    Private Sub GetFile(efiles As FileInfo(), nodetoadd As TreeNode)
        Dim aNode As TreeNode
        For Each thisfile As FileInfo In efiles
            aNode = New TreeNode(thisfile.Name, 1, 1)
            aNode.Tag = thisfile
            nodetoadd.Nodes.Add(aNode)
        Next

    End Sub
End Class