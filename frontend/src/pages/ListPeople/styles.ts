import styled from 'styled-components'

export const Container = styled.div`
  flex: 1;
  height: 100%;
  padding: 20px 30px;
`

export const Title = styled.h1`
  font-size: ${({ theme }) => theme.font.sizes.Large};
`

export const HeaderContainer = styled.div`
  flex: 1;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  margin: 20px 0 10px 0;
`

export const Row = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
`

export const Separator = styled.div`
  margin-right: 20px;
`
