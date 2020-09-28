using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMMAND
{
    class EditorMgr
    {
        public void CreateMob(string name, int x, int y)
        {
            Debug.Log(name + " 몹 생성, " + x + " 좌표, " + y + " 좌표에서 생성합니다.");
        }

        public void DeleteMob(string name, int x, int y)
        {
            Debug.Log(name + " 몹 제거, " + x + " 좌표, " + y + " 좌표에서 삭제합니다.");
        }
    }

    abstract class Command
    {
        public string MobName;
        public int PointX;
        public int PointY;

        public abstract void Execute();
    }

    class CreateCommand : Command
    {
        private EditorMgr editor;

        public CreateCommand(EditorMgr editor, string name, int x, int y)
        {
            this.editor = editor;
            this.MobName = name;
            this.PointX = x;
            this.PointY = y;
        }

        public override void Execute()
        {
            editor.CreateMob(MobName, PointX, PointY);
        }
    }

    class DeleteCommand : Command
    {
        private EditorMgr editor;

        public DeleteCommand(EditorMgr editor, string name, int x, int y)
        {
            this.editor = editor;
            this.MobName = name;
            this.PointX = x;
            this.PointY = y;
        }

        public override void Execute()
        {
            editor.DeleteMob(MobName, PointX, PointY);
        }
    }

    class MapEditor
    {
        private EditorMgr editor = new EditorMgr();
        private List<Command> CommandList = new List<Command>();
        private int m_iCurrent = 0;

        public void Create(string name, int x, int y)
        {
            Command command = new CreateCommand(editor, name, x, y);
            command.Execute();

            CommandList.Add(command);
            m_iCurrent++;
        }

        public void Delete(string name, int x, int y)
        {
            Command command = new DeleteCommand(editor, name, x, y);
            command.Execute();

            CommandList.Add(command);
            m_iCurrent++;
        }

        public void Redo(int level)
        {
            Debug.Log("Redo" + level + "Levels");
            for (int i = 0; i < level; i++)
            {
                if (m_iCurrent <= CommandList.Count - 1)
                {
                    Command command = CommandList[m_iCurrent++];
                    command.Execute();
                }
            }
        }

        public void Undo(int level)
        {
            Debug.Log("Undo" + level + "level");
            for (int i = 0; i < level; i++)
            {
                if (m_iCurrent > 0)
                {
                    Command command = CommandList[--m_iCurrent] as Command;

                    if ((command as CreateCommand) != null)
                    {
                        //생성일때 삭제처리
                        Command commandTemp = new DeleteCommand(editor, command.MobName, command.PointX, command.PointY);
                        commandTemp.Execute();
                    }
                    else
                    {
                        //삭제일때 생성처리
                        Command commandTemp = new CreateCommand(editor, command.MobName, command.PointX, command.PointY);
                        commandTemp.Execute();
                    }

                }
            }
        }
    }
}
